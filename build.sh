#!/usr/bin/env bash

set -euo pipefail

readonly PROJECT="StringCase"
readonly CWD="$(cd -- "$(dirname -- "${BASH_SOURCE[0]}")" && pwd)"

clean() {
  # dotnet clean -c Debug && dotnet clean -c Release  # Not enough
  find "${CWD}" -type d \( -name bin -o -name obj \) -prune -exec rm -rf {} +
}

compile() {
  dotnet build
}

format() {
  dotnet format
}

test() {
  dotnet test "${PROJECT}.Tests/${PROJECT}.Tests.csproj"
}

bench() {
  pushd StringCase.Benchmarks/
  dotnet run -c Release
  popd
}

deps() {
  dotnet package update
}

native_test() {
  export DOTNET_CLI_UI_LANGUAGE=en
  OS="$(uname -s)"
  ARCH="$(uname -m)"
  case "$OS" in
    Darwin)
      case "$ARCH" in
        x86_64)
          RID="osx-x64"
          ;;
        arm64)
          RID="osx-arm64"
          ;;
        *)
          echo "Unsupported macOS architecture: $ARCH" >&2
          exit 1
          ;;
      esac
      APPLE_MIN_OS_VERSION="$(sw_vers -productVersion | cut -f1-2 -d'.')"
      AOT_OPTIONS=(
        "-p:AppleMinOSVersion=$APPLE_MIN_OS_VERSION"
      )
      ;;
    Linux)
      case "$ARCH" in
        x86_64)
          RID="linux-x64"
          ;;
        aarch64 | arm64)
          RID="linux-arm64"
          ;;
        *)
          echo "Unsupported Linux architecture: $ARCH" >&2
          exit 1
          ;;
      esac
      AOT_OPTIONS=()
      ;;
  esac
  dotnet publish "${PROJECT}.NativeTests/${PROJECT}.NativeTests.csproj" -v diag -c Release -r "$RID" "${AOT_OPTIONS[@]}"
  find "${CWD}/${PROJECT}.NativeTests/bin/Release" -path "*/publish/${PROJECT}.NativeTests" -type f -name "${PROJECT}.NativeTests" -exec {} \;
}

if [[ "$#" == "0" ]]; then
  clean
  format
  compile
  test
  native_test
else
  for a in "$@"; do
    case "$a" in
    clean)
      clean
      ;;
    compile)
      compile
      ;;
    format)
      format
      ;;
    test)
      test
      ;;
    bench)
      bench
      ;;
    deps)
      deps
      ;;
    native-test)
      native_test
      ;;
    *)
      echo "Bad task: $a"
      exit 1
      ;;
    esac
  done
fi

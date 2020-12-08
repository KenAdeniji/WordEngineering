REM \emsdk\emsdk_env.bat
REM em++ ../cpp/StringWork.cpp -s WASM=1 -o StringWork.js || exit 1
em++ ../cpp/StringWork.cpp -s STANDALONE_WASM -s WASM=1 -s EXPORT_ALL=1 -s ERROR_ON_UNDEFINED_SYMBOLS=0 -o StringWork.html -s "EXTRA_EXPORTED_RUNTIME_METHODS=['ccall']"
REM wasm-dis StringWork.wasm -o StringWork.wast
move StringWork.js ../web/gen/
move StringWork.wasm ../web/gen/

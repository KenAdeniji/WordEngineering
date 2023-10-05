REM \emsdk\emsdk_env.bat
REM em++ ../cpp/BibleBookQuery.cpp ../cpp/BibleBook.cpp -s WASM=1 -o BibleBookQuery.js || exit 1
em++ ../cpp/BibleBook.cpp ../cpp/BibleBookQuery.cpp -s STANDALONE_WASM -s WASM=1 -s EXPORT_ALL=1 -s ERROR_ON_UNDEFINED_SYMBOLS=0 -o BibleBookQuery.html -s "EXTRA_EXPORTED_RUNTIME_METHODS=['ccall']"
REM wasm-dis BibleBookQuery.wasm -o BibleBookQuery.wast
move BibleBookQuery.js ../web/gen/
move BibleBookQuery.wasm ../web/gen/
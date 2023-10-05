@ECHO OFF
REM -s WASM=1 — Specifies that we want wasm output. If we don’t specify this, Emscripten will just output asm.js, as it does by default.
REM -o hello.html — Specifies that we want Emscripten to generate an HTML page to run our code in (and a filename to use), as well as the wasm module and the JavaScript "glue" code to compile and instantiate the wasm so it can be used in the web environment.
emcc hello.c -s WASM=1 -o hello.html


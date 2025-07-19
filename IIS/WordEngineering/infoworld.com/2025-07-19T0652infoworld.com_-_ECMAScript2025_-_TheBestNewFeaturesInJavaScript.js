import Census from "/WordEngineering/WordUnion/Census.json" with { type: "json" };
censusTableElement.innerHTML = JSON.stringify(Census);

const TribeNames = ["Asher", "Benjamin"];

tribesTableElement.innerHTML = "<table><thead><tr><th>Name</th><th>Length</th></tr></thead><tbody>" + Iterator.from(TribeNames).map(x => `<tr><td>${x}</td><td>${x.length}</td></tr>`).toArray();
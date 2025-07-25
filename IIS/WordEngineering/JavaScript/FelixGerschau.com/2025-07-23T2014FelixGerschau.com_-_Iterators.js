const userNamesGroupedByLocation = {
  Tokio: [
    'Aiko',
    'Chizu',
    'Fushigi',
  ],
  'Buenos Aires': [
    'Santiago',
    'Valentina',
    'Lola',
  ],
  'Saint Petersburg': [
    'Sonja',
    'Dunja',
    'Iwan',
    'Tanja',
  ],
};

userNamesGroupedByLocation[Symbol.iterator] = function() {
  const cityKeys = Object.keys(this);
  let cityIndex = 0;
  let userIndex = 0;

  return {
    next: () => {
      // We already iterated over all cities
      if (cityIndex > cityKeys.length - 1) {
        return {
          value: undefined,
          done: true,
        };
      }

      const users = this[cityKeys[cityIndex]];
      const user = users[userIndex];

      const isLastUser = userIndex >= users.length - 1;

      userIndex++;
      if (isLastUser) {
        // Reset user index
        userIndex = 0;
        // Jump to next city
        cityIndex++
      }

      return {
        done: false,
        value: user,
      };
    },
  };
};

for (let name of userNamesGroupedByLocation) {
  console.log('name', name);
}

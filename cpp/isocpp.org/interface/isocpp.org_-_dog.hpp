class Dog : public IAnimal { // an animal
public:
    Dog::Dog(std::string);          // constructor
	void Dog::SetDog(std::string);
	string Dog::getBreed();
	void Dog::setBreed(std::string);
	string Dog::sound() override;
public:
	string breed;
private:

};

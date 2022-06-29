#2022-06-28T20:39:00 Created. http://selenium-python.readthedocs.io/getting-started.html
import unittest #The unittest module is a built-in Python based on Java’s JUnit. This module provides the framework for organizing the test cases.
from selenium import webdriver
from selenium.webdriver.common.keys import Keys
from selenium.webdriver.common.by import By

class PythonOrgSearch(unittest.TestCase): #The test case class is inherited from unittest.TestCase. Inheriting from TestCase class is the way to tell unittest module that this is a test case:

    def setUp(self): #The setUp is part of initialization, this method will get called before every test function which you are going to write in this test case class. Here you are creating the instance of Firefox WebDriver.
        self.driver = webdriver.Firefox()

    def test_search_in_python_org(self): #This is the test case method. The test case method should always start with characters test. The first line inside this method create a local reference to the driver object created in setUp method.
        driver = self.driver
        driver.get("http://www.python.org")
        self.assertIn("Python", driver.title)
        elem = driver.find_element(By.NAME, "q")
        elem.send_keys("pycon")
        elem.send_keys(Keys.RETURN)
        self.assertNotIn("No results found.", driver.page_source)


    def tearDown(self):
        self.driver.close()

if __name__ == "__main__":
    unittest.main()
	
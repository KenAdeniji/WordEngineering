#2022-06-28T21:20:00 Created. http://selenium-python.readthedocs.io/navigating.html
from selenium import webdriver #The selenium.webdriver module provides all the WebDriver implementations. Currently supported WebDriver implementations are Firefox, Chrome, IE and Remote.
from selenium.webdriver.common.keys import Keys #The Keys class provide keys in the keyboard like RETURN, F1, ALT etc.
from selenium.webdriver.common.by import By #The By class is used to locate elements within a document.

driver = webdriver.Firefox() #Next, the instance of Firefox WebDriver is created.
navigateUrl = "file:///E:/WordEngineering/Python/selenium/python_selenium_navigating.html"
driver.get(navigateUrl) #The driver.get method will navigate to a page given by the URL. WebDriver will wait until the page has fully loaded (that is, the “onload” event has fired) before returning control to your test or script. Be aware that if your page uses a lot of AJAX on load then WebDriver may not know when it has completely loaded:

element = driver.find_element(By.ID, "passwd-id")
element = driver.find_element(By.NAME, "passwd")
element = driver.find_element(By.XPATH, "//input[@id='passwd-id']")
element = driver.find_element(By.CSS_SELECTOR, "input#passwd-id")

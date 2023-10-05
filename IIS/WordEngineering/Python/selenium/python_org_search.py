#2022-06-27 Created. http://#selenium-python.readthedocs.io/getting-started.html
from selenium import webdriver #The selenium.webdriver module provides all the WebDriver implementations. Currently supported WebDriver implementations are Firefox, Chrome, IE and Remote.
from selenium.webdriver.common.keys import Keys #The Keys class provide keys in the keyboard like RETURN, F1, ALT etc.
from selenium.webdriver.common.by import By #The By class is used to locate elements within a document.

driver = webdriver.Firefox() #Next, the instance of Firefox WebDriver is created.
driver.get("http://www.python.org") #The driver.get method will navigate to a page given by the URL. WebDriver will wait until the page has fully loaded (that is, the “onload” event has fired) before returning control to your test or script. Be aware that if your page uses a lot of AJAX on load then WebDriver may not know when it has completely loaded:
assert "Python" in driver.title #The next line is an assertion to confirm that title has “Python” word in it:
elem = driver.find_element(By.NAME, "q") 
elem.clear() #Next, we are sending keys, this is similar to entering keys using your keyboard. Special keys can be sent using Keys class imported from selenium.webdriver.common.keys. To be safe, we’ll first clear any pre-populated text in the input field (e.g. “Search”) so it doesn’t affect our search results:
elem.send_keys("pycon")
elem.send_keys(Keys.RETURN)
assert "No results found." not in driver.page_source #After submission of the page, you should get the result if there is any. To ensure that some results are found, make an assertion:
driver.close() #Finally, the browser window is closed. You can also call quit method instead of close. The quit will exit entire browser whereas close will close one tab, but if just one tab was open, by default most browser will exit entirely.:

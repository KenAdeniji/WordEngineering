"""
2020-04-01	https://github.com/ithaka/apiron
2020-04-01	pip install apiron
"""

from apiron import JsonEndpoint, Service

class GitHub(Service):
    domain = 'https://api.github.com'
    user = JsonEndpoint(path='/users/{username}')
    repo = JsonEndpoint(path='/repos/{org}/{repo}')
	
response = GitHub.user(username='defunkt')
print(response)
# {"name": "Chris Wanstrath", ...}
print("name: ", response["name"])

response = GitHub.repo(org='github', repo='hub')
print(response)
# {"description": "hub helps you win at git.", ...}
print("description: ", response["description"])

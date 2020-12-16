if __name__ == '__main__':
    import os
    print(os.getcwd())
    #print(dir(os))
    #help(os)
    
    import shutil
    #shutil.copyfile('data.db','archive.db')
    #shutil.move('/build/executables','installdir')

    import glob
    print(glob.glob("*.py"))

    import sys
    print(sys.argv)
    
    import re
    print(re.findall(r'\bf[a-z]*','which foot or hand fell fastest'))
    
    print('tea for too'.replace('too','two'))

    import math
    print(math.cos(math.pi/4))
    print(math.log(1024,2))

    import random
    print(random.choice(['apple','pear','banana']))
    print(random.sample(range(100),10))# sampling without replacement
    print(random.random())
    print(random.randrange(6))# random integer chosen from range(6)

    import statistics
    data=[2.75,1.75,1.25,0.25,0.5,1.25,3.5]
    print(statistics.mean(data))
    print(statistics.median(data))
    print(statistics.variance(data))
    
    from urllib.request import urlopen
    with urlopen('http://tycho.usno.navy.mil/cgi-bin/timer.pl') as response:
        for line in response:
            line=line.decode('utf-8')# Decoding the binary data to text.
            if 'EST' in line or 'EDT' in line:# look for Eastern Time
                print(line)

    import smtplib
    server = smtplib.SMTP("localhost")
    server.sendmail
    (
        "soothsayer@example.org",
        "jcaesar@example.org",
        ***
            To: jcaesar@example.org
            From: soothsayer@example.org

            Beware the Ides of March.
        ***
    )
    server.quit()
    

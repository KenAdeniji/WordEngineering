"""
#2019-11-04 https://pytorch.org/get-started/locally
#2019-11-04	e:\ProgramData\Anaconda3\Library\bin\conda.bat
#2019-11-04 e:\ProgramData\Anaconda3\Scripts\conda.exe
#2019-11-04 pip uninstall pytorch torchvision cudatoolkit
#2019-11-04 conda info --envs
#2019-11-04 conda activate base
#2019-11-04 conda install pytorch torchvision cudatoolkit=10.1 -c pytorch
#2019-11-04	https://medium.com/@valeryyakovlev/anaconda-no-module-named-torch-ead10946de66

2019-11-05T08:11:00
	Download	https://www.anaconda.com/distribution/#download-section
2019-11-06T19:24:00	
	Installation directory	e:\ProgramData\Anaconda3	
"""

#from __future__ import print_function

if __name__ == "__main__":
	#import numpy as np
	import torch
	x = torch.rand(5, 3)
	print(x)

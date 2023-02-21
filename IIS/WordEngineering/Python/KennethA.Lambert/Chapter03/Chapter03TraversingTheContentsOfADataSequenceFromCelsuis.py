"""
	2020-02-04	http://luccisun.webfactional.com/sbc/docs/FundamentalsofPythonFromFirstProgramsthroughDataStructures2009_KA_Lambert.pdf
"""
celsuisList = [0, 20, 40, 60, 80, 100]
for celsuis in celsuisList:
	print("%-3d%12.2f" % (celsuis, (celsuis * 9.0 / 5.0) + 32))

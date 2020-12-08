"""
2019-03-08	https://www.geeksforgeeks.org/python-data-visualization-using-bokeh/
2019-03-08	pip install bokeh
2019-03-08	pip install ipython
"""

def dataVisualizationUsingBokeh():
	# import modules 
	from bokeh.plotting import figure, output_notebook, show 
	  
	# output to notebook 
	output_notebook() 
	  
	# create figure 
	p = figure(plot_width = 400, plot_height = 400) 
	  
	# add a circle renderer with 
	# size, color and alpha 
	p.circle([1, 2, 3, 4, 5], [4, 7, 1, 6, 3],  
			 size = 10, color = "navy", alpha = 0.5) 
	  
	# show the results 
	show(p)  
		
if __name__ == '__main__':
	dataVisualizationUsingBokeh()
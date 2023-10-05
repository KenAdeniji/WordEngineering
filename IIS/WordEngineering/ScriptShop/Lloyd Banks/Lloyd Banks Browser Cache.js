			//2015-05-15 http://stackoverflow.com/questions/118884/what-is-an-elegant-way-to-force-browsers-to-reload-cached-css-js-files
			(function(){

				// Match this timestamp with the release of your code
				var lastVersioning = Date.UTC(2015, 4, 15, 17, 35, 1);

				var lastCacheDateTime = localStorage.getItem('lastCacheDatetime');

				if(lastCacheDateTime){
					if(lastVersioning > lastCacheDateTime){
						var reload = true;
					}
				}

				localStorage.setItem('lastCacheDatetime', Date.now());

				if(reload){
					location.reload(true);
				}

			})();		

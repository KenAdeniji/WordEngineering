/*
	http://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Statements/export
	2024-08-10T20:42:00...2024-08-10T21:14:00
	http://stackoverflow.com/questions/56296073/how-to-get-all-variables-including-constants/56296227#56296227
	2024-08-10T23:03:00...2024-08-10T23:17:00
		http://stackoverflow.com/questions/31173473/list-all-global-variables-in-node-js
*/	

// Exporting declarations
export const
	github = "http://github.com/KenAdeniji",
	linkedin = "http://linkedin.com/in/ken-adeniji-1631844",
	stackoverflow = "http://stackoverflow.com/users/10497357/ken-adeniji",
	wordpress = "http://KenAdeniji.WordPress.com"
	;

export function functionNameBrowser() 
{
	Object.getOwnPropertyNames(window).forEach
	(
		key => 
		{
			console.log(`key: ${key}. value: ${window[key]}`);
		}
	)
}

export function functionNameNode() 
{
	Object.getOwnPropertyNames(this).forEach
	(
		key => 
		{
			console.log(`key: ${key}. value: ${this[key]}`);
		}
	)
}

export class ClassName { /* … */ }
export function* generatorFunctionName() { /* … */ }
/*
export const 
{ 
	github: githubUrl,
	linkedin: linkedinUrl,
	stackoverflow: stackoverflowUrl,
	wordpress: wordpressUrl
} = javascriptObjectNotation;
*/
/*
export const 
[ 
	github,
	linkedin,
	stackoverflow,
	wordpress,
] = array;
*/

let socialMediaAPI = 
{
	github,
	linkedin,
	stackoverflow,
	wordpress,
	functionNameNode
}

export default socialMediaAPI

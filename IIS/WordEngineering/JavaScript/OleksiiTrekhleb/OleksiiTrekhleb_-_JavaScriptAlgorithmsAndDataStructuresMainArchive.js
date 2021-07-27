/*
	2021-07-26T07:33:00 Created.
*/
import * as Module from "./modules/OleksiiTrekhleb_-_JavaScriptAlgorithmsAndDataStructuresModule.js";

resultSetElement.innerHTML = 
	`
		<table>
			<caption>Oleksii Trekhleb JavaScript Algorithms and Data Structures</caption> 
 			<thead>
				<tr>
					<th>Signature</th>				
					<th>Example</th>
					<th>Original</th>
					<th>Custom</th>
					<th>Validate</th>
				</tr>
			</thead>
 			<tbody>
				<tr>
					<td>getBit(number, bitPosition)</td>
					<td>getBit(10, 2)</td>
					<td>${Module.getBit(10, 0)}</td>
					<td>${Module.getBitCustom(10, 0)}</td>
					<td>${Module.getBit(10, 0) === Module.getBitCustom(10, 0)}</td>
				</tr>
			</tbody>
		</table>	
	`;	

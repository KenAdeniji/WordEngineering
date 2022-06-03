/* 
	2022-06-03T09:03:00 Created.
	2022-06-03T09:19:00	http://doc.rust-lang.org/book/ch12-01-accepting-command-line-arguments.html
*/
use std::env;

fn main() {
    let args: Vec<String> = env::args().collect();
	for index in 1..args.len() {
		let uppercase = args[index].to_uppercase();
		let mut alphabet_sequence_index = 0;
		for current_character in uppercase.chars() { 
			if current_character >= 'A' && current_character <= 'Z' {
				let ascii_value = current_character as u32;	
				alphabet_sequence_index += ascii_value - 64;
			}	
		}
		println!
		(
			"Word[{0}]: {1} AlphabetSequenceIndex: {2}",
			index,
			args[index],
			alphabet_sequence_index
		);
	}	
}

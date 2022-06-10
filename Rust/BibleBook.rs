/* 
	2022-06-06T19:14:00	https://doc.rust-lang.org/stable/book/ch05-01-defining-structs.html
*/

struct BibleBook {
    id: u32,
    title: String
}

fn main() {
    let genesis = BibleBook {
		id: 1,
        title: String::from("Genesis")
    };	
	println!
	(
		"{0} {1}",
		genesis.id,
		genesis.title
	);
}

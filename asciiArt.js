/* This is my solution to the Ascii Art exercise on Codingame.com: http://www.codingame.com/challenge2_question1 */

asciiGenerator = function() {
	this.width;
	this.height;
	this.text;
	this.ascii = new Array();
	
	this.init = function() {
		this.width = readline();	//read 1
		this.height = readline();	//read 2
	}
	
	this.readText = function() {
		// Read in the string, make it upper case, replace any non-alpha characters with question marks, and put each character into an array
		var regex = new RegExp(/[^A-Z]/g);	// Used to replace any non-alpha characters with a question mark
		this.text = readline().toUpperCase().replace(this.regex,"?").split("");	//read 3
	}
	
	this.readAsciiMappings = function() {
		var row;
		var alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ?".split("");
		// Loop once for each row that will be read in
		for (i = 0; i < this.height; i++) {
			row = readline();		//read 4
			this.ascii[i] = new Array();
			// Loop once for each letter of the alphabet + '?', chopping up the row into array elements of the defined width, setting each letter as a key in the array
			for(j = 0; j < alphabet.length; j++) {
				this.ascii[i][alphabet[j]] = row.substr(j * this.width,this.width);
			}
		}
	}
	
	this.convertToAscii = function() {
		var buffer = "";
		// Loop once for each row
		for (i = 0; i < this.height; i++) {
			// Loop once for each character in the text array
			for(j = 0; j < this.text.length; j++) {
				buffer += this.ascii[i][this.text[j]];
			}
			print(buffer);
			buffer = "";
		}
	}
}

var myAsciiGenerator = new asciiGenerator();
myAsciiGenerator.init();
myAsciiGenerator.readText();
myAsciiGenerator.readAsciiMappings();
myAsciiGenerator.convertToAscii();


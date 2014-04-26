/* This is my solution to the Ascii Art exercise on Codingame.com: http://www.codingame.com/challenge2_question1
 * TODO:
 * * Convert this to a class
 * * Use key-value pairs instead of using indexOf() */
var width = readline();
var height = readline();
var regex = new RegExp(/[^A-Z]/g);
var tmpText = readline().toUpperCase().replace(regex,"?");
//var tmpText = tmpArr.join("");
//print(tmpText);
var text = tmpText.split("");

var ascii = new Array();
var row;
var alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ?".split("");
var buffer = "";

for (i = 0; i < height; i++) {
    row = readline();
    //print(row);
    ascii[i] = new Array();
    for(j = 0; j < width * 26; j++) {
        ascii[i][j] = row.substr(j * width,width); // This would perform a little better if this used keys instead of iterating through
        //print(ascii[i][j]);
    }
}

//print(ascii[0][0]);

for (i = 0; i < height; i++) {
    for(j = 0; j < text.length; j++) {
        pos = alphabet.indexOf(text[j]);
        buffer += ascii[i][pos];
    }
    print(buffer);
    buffer = "";
}

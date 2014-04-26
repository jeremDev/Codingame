// This is my partial solution to the MIME type challenge on codingame.com: http://www.codingame.com/challenge_maroc1_question1 

var n = readline();
var q = readline();
var lookup = new Array();
var filename;
var result;

for (var i = 0; i < n; i++) {
    lookup[i] = readline().split(" ");
    lookup[i][2] = new RegExp("\\." + lookup[i][0].replace("/","\\/") + "$","i");
}
//print(lookup.join(" "));  //DEBUGGING
for(var j = 0; j < q; j++) {
    result = "UNKNOWN";
    filename = readline();
    //print (filename);     //DEBUGGING
    if(filename != "")
		for(var i = 0; i < n; i++) {
			if(lookup[i][2].test(filename)) {
				result = lookup[i][1];
				break;
			}
		}
    print(result);
}

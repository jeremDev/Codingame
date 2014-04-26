// My solution to the Chuck Norris exercise on Codingame.com: http://www.codingame.com/challenge_janvier_2013_question1

var n = readline().split("");
var theBin = "";

for (var i = 0; i < n.length; i++) {
    tmp =n[i].charCodeAt(0).toString(2);
    if(tmp.length < 7)
        tmp = "0" + tmp;
    theBin += tmp;
}

print(BinaryToUnary(theBin));

function BinaryToUnary(bin) {
    var counter = 0;
    var ret;
    var tmp = bin.substr(0,1);
    if(tmp == 0)
        ret = "00 ";
    else
        ret = "0 ";
    for(i = 0; i < bin.length; i++)
        if(bin[i] == tmp) {
            ret = ret + "0";
            counter++;
        }
        else
            break;
    bin = bin.substring(counter, bin.length);
    if(bin.length == 0)
        return ret;
    else
        return ret + " " + BinaryToUnary(bin);
}

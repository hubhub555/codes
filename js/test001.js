/*あるルールで圧縮された文字列を、元の文字列に解凍するプログラムを作成してください
* 圧縮された文字列は小文字と数字(1~9)だけで構成されています
* 数字は、その直前までに解凍された文字列をN回繰り返します
* 繰り返しは1~9回までです。
例(解凍のステップを示しています)
a2b3 => aab3 => aabaabaab
abc2de2 => abcabcde2 => abcabcdeabcabcde
abcde => abcde (数字が含まれていない場合もあります)
abc1de1 => abcde1 => abcde
*/
//const a = "a2b3";
const a = "abc2de2";
//const a = "abcde";
//const a = "abc1de1";

function zip(a) {

    console.log("------Start-----");

    //文字列を配列にぶち込む
    let str = "";
    let ary = a.split("");

    const containsNumber = ary.some(item => /\d/.test(item));
    if (!containsNumber) {
        console.log(a);
        return ary;
    }

    //配列の要素数を取得
    const len = ary.length;
    let result = [];
    let result2 = [];

    for (let i = 0; i < len; i++) {
        if (ary[0].match(/[a-z]/)) {
            result[i] = ary[0];
            ary.shift();
        } else if (ary[0].match(/[1-9]/)) {
            for (let j = 0; j < ary[0]; j++) {
                result2.push(...result);
            }
            ary.shift();
            break;
        }
    }

    result2.push(...ary);
    str = result2.join('');

    console.log("str:" + str);

    zip(str);

    //console.log(zip())
    return str;
}

zip(a)
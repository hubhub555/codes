//文字列を空白を取りのぞく正規化をして、配列にぶち込む
// .split(str)はstrで文字列を区切り、配列にぶち込む
// "/"は正規表現の開始と終了
// "\s"は空白文字に一致
// "+"は一回以上の繰り返し


//入力値が文字列の時、空白の正規表現の後に配列にぶち込む
const exam1 = () => {
    const str = "1 80 20";
    const nums = str.split(/\s+/);
    return nums;
}

//入力値が配列の時、空白の正規表現の後に配列にぶち込む
const exam2 = () => {
    const ary = ["0", "112", "a 1kchec"]
    const nums = ary.map((elm) => {
        return parseInt(elm.split(/\s+/));
    });
    return nums;
}

//入力値が配列かつ空白が混ざった文字列の時、空白の正規表現の後に配列にぶち込む
const exam3a = () => {
    const ary = ["0 112", "123 23"];
    const nums = ary.flatMap(str => str.split(/\s+/).map(Number));
    return nums;
}

//入力値が配列かつ空白が混ざった文字列の時、空白の正規表現の後に配列にぶち込む
const exam3b = () => {
    const ary = ["0 112", "123 23"];
    const result = [];
    for (let i = 0; i < ary.length; i++) {
        const numbers = ary[i].split(" ").map(Number);
        result.push(...numbers);
    }
    return result;
}

const exam4 = () => {
    const result = ["OK", "NG", "OK"];
    return result.join('\n');
}


const exam5 = () => {
    const ary = str.split("");
    return ary.join("\n");
}


console.log("exam1:" + exam1());
console.log("exam2:" + exam2());
console.log("exam3a:" + exam3a());
console.log("exam3b:" + exam3b());
console.log("exam14:" + exam4());



//車間距離が10未満の距離の合計

//input ary[]
//5 10
//5
//6
//25
//4

const distance = (ary) => {
    //imput[0]から空白を取り除く正規化
    const imput = ary[0].split(/\s+/);
    const carDistance = imput[1];
    //配列aryから１番目の要素を取り除きnewAryに格納する
    const newAry = ary.slice(1);
    //配列newAryのすべての要素から空白を取り除く正規化を行い、数値化したものを配列numに格納する
    const nums = newAry.map((elm) => {
        return parseInt(elm.split(/\s+/));
    });
    //accumulato(累積)にcurrentValueを足す
    const sum = nums.reduce((accumulator, currentValue) => {
        if (currentValue <= carDistance) {
            return accumulator + currentValue;
        } else {
            return accumulator;
        }
    }, 0);

    return sum;
}


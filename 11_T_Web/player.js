const audio = document.getElementById("audio");
const controlPanel = document.getElementById("controlPanel");

const funcBtn = controlPanel.getElementsByTagName("span");
const input = controlPanel.getElementsByTagName("input");
const musicList = controlPanel.getElementsByTagName("select")[0];
const infoPanel = controlPanel.getElementsByTagName("div");

//console.log(infoPanel[0]);  //偵錯用

const btnPlay = funcBtn[0];
const btnMuted = funcBtn[6];
const volRangeBar = input[0];
const txtVol = input[3];
const progressBar = input[4];
const status = infoPanel[2];

//取得時間格式
function getTimeFormat(t) {
    let m = parseInt(t / 60);
    let s = parseInt(t % 60);

    m = m < 10 ? "0" + m : m;
    s = s < 10 ? "0" + s : s;

    return m + ":" + s;
}

//單曲循還
function setCircle() {
    status.innerText = status.innerText == "單曲循環" ? "正常" : "單曲循環";
}

//隨機播放
function setRandom() {
    status.innerText = status.innerText == "隨機播放" ? "正常" : "隨機播放";
}

//全曲循環
function setAllLoop() {
    status.innerText = status.innerText == "全曲循環" ? "正常" : "全曲循環";
}

//歌曲進度顯示
function getMusicTime() {
    infoPanel[0].innerText = getTimeFormat(audio.currentTime) + " / " + getTimeFormat(audio.duration); //歌曲寺間

    progressBar.value = audio.currentTime * 10000;  //進度條
    console.log(progressBar.value);

    //塗進度條的顏色
    let w = audio.currentTime / audio.duration * 100;
    progressBar.style.backgroundImage = `-webkit-linear-gradient(left,rgb(197, 7, 0) ${w}%, rgb(236, 236, 234) ${w}%)`;

}

function setProgress() {
    audio.currentTime = progressBar.value / 10000;
}


//每首歌曲播完時判斷歌曲播畢要做什麼事
function musicStatus() {

    if (status.innerText == "單曲循環") {
        changeMusic(0);
    }
    else if (status.innerText == "隨機播放") {
        let n = Math.floor(Math.random() * musicList.children.length);//得到一個隨機0~n-1的整數
        n -= musicList.selectedIndex;
        changeMusic(n);
    }
    else if (status.innerText == "全曲循環") {
        if (musicList.length == musicList.selectedIndex + 1)
            changeMusic(0 - musicList.selectedIndex);
    }
    else if (musicList.length == musicList.selectedIndex + 1) { //是否為最後一首歌
        stopMusic();
    }
    else { //不是最後一首歌就播下一首歌
        changeMusic(1);
    }

}


//切換歌曲
function changeMusic(n) {
    let i = musicList.selectedIndex; //抓使用者選到的選項索引值
    audio.src = musicList.children[i + n].value; //抓使用者選到的選項value屬值
    audio.title = musicList.children[i + n].innerText;
    musicList.children[i + n].selected = true;

    if (btnPlay.innerText == ";")
        audio.onloadeddata = playMusic;  //歌曲載完才呼叫playMusic函數

}


setVolumeByRangeBar();  //初始音量
//音量調整
function setVolumeByRangeBar() {
    audio.volume = volRangeBar.value / 100;
    txtVol.value = volRangeBar.value;

    //塗音量條的顏色
    volRangeBar.style.backgroundImage = `-webkit-linear-gradient(left,rgb(247, 133, 41) ${volRangeBar.value}%, rgb(236, 236, 234) ${volRangeBar.value}%)`;
}

function setVolume(n) {
    volRangeBar.value = parseInt(volRangeBar.value) + n;
    setVolumeByRangeBar();
}


//設定為靜音
function setMute() {
    audio.muted = !audio.muted;
}

//音樂快轉或倒轉
function changeTime(s) {
    audio.currentTime += s;
}


//音樂停止
function stopMusic() {
    //1.音樂停下來  2.時間歸零
    pauseMusic();//1.音樂停下來 
    audio.currentTime = 0;//  2.時間歸零
    infoPanel[1].innerText = "音樂停止";

}

//音樂暫停
function pauseMusic() {
    audio.pause();
    btnPlay.innerText = "4";//改變外觀
    btnPlay.onclick = playMusic;
    infoPanel[1].innerText = "音樂暫停中...";

}

//播放音樂
function playMusic() {
    audio.play();  //播放音樂
    btnPlay.innerText = ";";//改變外觀
    btnPlay.onclick = pauseMusic;
    infoPanel[1].innerText = "正在播放" + audio.title + "中...";

    setInterval(() => getMusicTime(), 0.1);

    progressBar.max = audio.duration * 10000;
    console.log(progressBar.max);

}
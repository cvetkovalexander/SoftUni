


function songsFunc(arr) {

    class Song {

        constructor(typeList, name, time) {
            this.typeList = typeList;
            this.name = name;
            this.time = time;
        }
    }

    let count = arr.shift();
    let typeList = arr.pop();

    let songs = [];

    for (const str of arr) {
        let [typeList, name, time] = str.split('_');
        let song = new Song(typeList, name, time);
        songs.push(song);
    }

    if (typeList == "all") {
        for (const song of songs) {
            console.log(song.name);
        }
    }
    else {
        for (const song of songs.filter(x => x.typeList == typeList)) {
            console.log(song.name);
        }
    }

}


songsFunc([4,
'favourite_DownTown_3:14',
'listenLater_Andalouse_3:24',
'favourite_In To The Night_3:58',
'favourite_Live It Up_3:48',
'listenLater']
);
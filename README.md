# unity-tweet
unityで画像付きツイートができるライブラリです。   

https://user-images.githubusercontent.com/96648305/192074593-95e3c277-6aac-4e93-bbef-aae1bb2b0b2b.mp4  

## 対応環境
* WIndows
* UnityEditor  

## インストール方法

#### パッケージから
1. https://github.com/saitocastel1900/unity-tweet/releases/ から最新のPackageをダウンロード  
2. Unityのアセット=>パッケージをインポート＝＞カスタムパッケージからダウンロードしたPackageを選択

#### CLIから
1. Node.jsをインストール  
2. openpumを使えるようにするため以下のコードをcmdで実行
3. ```https://github.com/saitocastel1900/unity-tweet.git?=Packages/unity-tweet/```

```
npm install -g openupm-cli
```
3. インストールしたいUnityのプロジェクトに移動して、以下をcmdで実行
```
openupm add dev.makaroni.unity-tweet
```

## 使い方
**事前にGyazoAPIの登録が必要です。詳しくは検索してみてください。**  
![スクリーンショット 2022-09-24 111033](https://user-images.githubusercontent.com/96648305/192075714-b03f288a-6565-493a-b45b-41bd4cf54dd8.png)  

1. GyazoAPIの準備が出来たら、アクセストークンをメモしておく

2. 以下の様にそれぞれの処理を呼び出して、アクセストークンを設定する（ツイートしたい文言などもサンプルなどの様に設定する）
```
//Sample TweetSample.cs
[Header("GyazoAPIのアクセストークンをここに設定"),SerializeField]
    private string accesstoken=null;
    
    [Header("Tweetしたい文字をここに設定"),SerializeField]
    private string text=null;
    [Header("タグにしたい文字をここに設定"),SerializeField]
    private string[] hashtag=null;

    [SerializeField] private Button _button;

   async UniTask Start()
    {
        _button.OnClickAsObservable().Subscribe(async _ =>
        {
             //スクショする
             Texture2D tex = await CaptureTweet.CaptureScreenshot(this.GetCancellationTokenOnDestroy());
             
             //画像をGyazoにあげる
             var url=await CaptureTweet.ImgUpload(tex,accesstoken,new CancellationTokenSource()); 
             
             //Gyazoにあげた画像のURLをつけてツイートする
             CaptureTweet.Tweet(text,hashtag,url);
             
             Destroy(tex);
        }).AddTo(this);
    }
```

## ライセンス

```
MIT License

Copyright (c) 2022 Ryoma Saito(Dedicated School Account)

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
```

using System.Threading;
using UniRx;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Tweet
{
    public class TweetSample : MonoBehaviour
    {
        [Header("GyazoAPIのアクセストークンをここに設定"), SerializeField]
        private string accesstoken = null;

        [Header("Tweetしたい文字をここに設定"), SerializeField]
        private string text = null;

        [Header("タグにしたい文字をここに設定"), SerializeField]
        private string[] hashtag = null;

        [SerializeField] private Button _button;

        // Start is called before the first frame update
        async UniTask Start()
        {
            _button.OnClickAsObservable().Subscribe(async _ =>
            {
                Texture2D tex = await CaptureTweet.CaptureScreenshot(this.GetCancellationTokenOnDestroy());
                var url = await CaptureTweet.ImgUpload(tex, accesstoken, new CancellationTokenSource());
                CaptureTweet.Tweet(text, hashtag, url);
                Destroy(tex);
            }).AddTo(this);
        }
    }
}
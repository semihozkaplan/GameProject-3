using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using ProjectGame3.Enums;


namespace ProjectGame3.Managers
{

    public class GameManager : MonoBehaviour
    {

        [SerializeField] int score;

        private const string PLAYER_SCORE = "Player_Score";  //C programlama dilinde #define ile aynı işlevi görüyor sabit yani.

        public static GameManager Instance { get; private set; }

        public int Score => this.score;

        public event System.Action<SceneTypeEnums> OnSceneChanged;
        public event System.Action<int> OnScoreChanged;
        
    
        private void Awake()
        {

            Singleton();

        }


        private IEnumerator Start()
        {

            yield return SceneManager.LoadSceneAsync("Menu", LoadSceneMode.Additive);
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("Menu"));

            if (PlayerPrefs.HasKey(PLAYER_SCORE))  // Eğer elimizde bir key var ise işlem yap, bunu yapmazsak hata verebilir.
            {
                score = PlayerPrefs.GetInt(PLAYER_SCORE);  // PlayerPrefs.GetInt ile setlediğimiz değeri çağır. Tabiki set ederken PLAYER_SCORE keyini kullandık o yüzden bu keyi çağırıyoruz.
            }

        }

        private void Singleton()
        {

            if (Instance == null)
            {

                Instance = this;
                DontDestroyOnLoad(this.gameObject);

            }

            else
            {

                Destroy(this.gameObject);

            }

        }

        public void LoadingScreen(SceneTypeEnums sceneType)
        {

            StartCoroutine(LoadingScreenAndStartAsync(sceneType));

        }

        private IEnumerator LoadingScreenAndStartAsync(SceneTypeEnums sceneType)
        {

            //Loading Scene and Loading Objects Operations
            yield return SceneManager.LoadSceneAsync(SceneTypeEnums.SplashScreen.ToString(), LoadSceneMode.Additive);
            OnSceneChanged?.Invoke(SceneTypeEnums.SplashScreen);
            yield return SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("SplashScreen"));

            yield return new WaitForSeconds(5f);

            //Game Scene and Game Objects Operations
            yield return SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
            yield return SceneManager.LoadSceneAsync(sceneType.ToString(), LoadSceneMode.Additive);
            OnSceneChanged?.Invoke(sceneType);
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneType.ToString()));

        }

        public void IncreaseScore(int score)
        {

            this.score += score;
            OnScoreChanged?.Invoke(this.score);

        }

        public void QuitGame()
        {

            Application.Quit();

        }

        public void DecreaseScore(int score)
        {

            this.score -= score;
            OnScoreChanged?.Invoke(this.score);

        }

        public void SaveScore() // Score u saveleme işlemi burda oluyor.
        {

           // Elimizdeki score u PLAYER_SCORE keyine setle ve çağırdığımızda yine bu keyden çağır.
           // Bu methodu PlayerController scriptinde OnDead eventine atıyoruz. 
           PlayerPrefs.SetInt(PLAYER_SCORE, score);  

        }

    }


}


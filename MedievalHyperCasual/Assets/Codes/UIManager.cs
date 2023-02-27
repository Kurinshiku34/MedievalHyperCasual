using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
    [SerializeField] Toggle muteButton;
    [SerializeField] Toggle vibrationButton;
    private bool vibrationActive = true;
    private float volume;
    const string MIXER_MASTER = "Master";
    public float xp, money;
    private void Awake()
    {
        LoadData();
        Time.timeScale = 0.0f;
    }
    private void Update()
    {
        SaveData();
        //titreþim modunun kontrolü
        if (muteButton.isOn == false)
        {
            volume = 0;
            mixer.SetFloat(MIXER_MASTER, volume);
        }
        else
        {
            volume = -80;
            mixer.SetFloat(MIXER_MASTER, volume);
        }

        if (vibrationActive == true)
        {
            vibrationButton.isOn = true;
            PlayerPrefs.SetInt("vibrationActive", 1);
        }
        else
        {
            vibrationButton.isOn = false;
            PlayerPrefs.SetInt("vibrationActive", 0);
        }
    }
    public void SaveData() // xp, money, settings, towns, others(tables,furnace,furniters,extc)
    {
        PlayerPrefs.SetInt("vibrationActive", vibrationActive ? 1 : 0);
        PlayerPrefs.SetInt("isMuted", muteButton.isOn ? 1 : 0);
        PlayerPrefs.SetFloat("xp", xp);
        PlayerPrefs.SetFloat("money", money);
    }
    public void LoadData()
    {
        vibrationActive = PlayerPrefs.GetInt("vibrationActive") == 1 ? true : false;
        muteButton.isOn = PlayerPrefs.GetInt("isMuted") == 1 ? true : false;
        xp = PlayerPrefs.GetFloat("xp");
        money = PlayerPrefs.GetFloat("money");
    }
    public void SceneChanger(int scenenumber)
    {
        SceneManager.LoadScene(scenenumber);
    }
    public void TimeScale(float scale)
    {
        Time.timeScale = scale;
    }
}

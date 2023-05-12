using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TopKontrol : MonoBehaviour
{
    [Header("Atamalar")]
    [SerializeField] GameObject _halka;
    [SerializeField] GameObject _renkTekeri;
    [SerializeField] GameObject _settingsPanel;
    Rigidbody2D _rigidbody;

    [Header("User Inteface Atamalari")]
    [SerializeField] Text _scoreText;
    [SerializeField] Text _bestScoreText;

    [Header("Degiskenler")]
    [SerializeField] float _ziplamaKuvveti = 3f;
    [SerializeField] string _mevcutRenk;
    [SerializeField] Color _topunRengi;
    [SerializeField] Color _turkuaz, _sari, _mor, _pembe;

    float _score = 0f;
    bool _basildiMi = false, _oyunBaslasin = false;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        _scoreText.text = "Score: " + _score;
        _bestScoreText.text = "BestScore : " + PlayerPrefs.GetFloat("BestScore",0);
        RastgeleRenkBelirle();
    }
    private void Update()
    {
        if (!_oyunBaslasin || _settingsPanel.activeInHierarchy == true)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
            if (transform.position.y < -5)
                RestartGame();
            if (Input.GetMouseButtonDown(0))
                _basildiMi = true;
            else if (Input.GetMouseButtonUp(0))
                _basildiMi = false;
            return;
        }
        if (Input.GetMouseButtonDown(0))
            _oyunBaslasin = true;
    }
    private void FixedUpdate()
    {
        if (_basildiMi)
            _rigidbody.velocity = Vector2.up * _ziplamaKuvveti;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("RenkTekeri"))
        {
            RastgeleRenkBelirle();
            Destroy(collision.gameObject);
            return;
        }
        if (collision.CompareTag("PuanArttirici"))
        {
            _score += 5;
            _scoreText.text = "Score: " + _score;
            if (PlayerPrefs.GetFloat("BestScore") < _score)
                PlayerPrefs.SetFloat("BestScore", _score);
            Destroy(collision.gameObject);
            Instantiate(_halka, new Vector3(transform.position.x, transform.position.y + 8f, transform.position.z), Quaternion.identity);
            Instantiate(_renkTekeri, new Vector3(transform.position.x, transform.position.y + 11f, transform.position.z), Quaternion.identity);
        }
        if (collision.tag != _mevcutRenk && !collision.CompareTag("PuanArttirici"))
        {
            _score = 0;
            RestartGame();
        }
    }

    void RastgeleRenkBelirle()
    {
        int rastgeleSayi = Random.Range(0, 4);
        switch (rastgeleSayi)
        {
            case 0:
                _mevcutRenk = "Turkuaz";
                _topunRengi = _turkuaz;
                break;
            case 1:
                _mevcutRenk = "Sari";
                _topunRengi = _sari;
                break;
            case 2:
                _mevcutRenk = "Pembe";
                _topunRengi = _pembe;
                break;
            case 3:
                _mevcutRenk = "Mor";
                _topunRengi = _mor;
                break;
        }
        GetComponent<SpriteRenderer>().color = _topunRengi;
    }

    void RestartGame()
    {
        _bestScoreText.text = "BestScore : " + PlayerPrefs.GetFloat("BestScore");
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}/**/

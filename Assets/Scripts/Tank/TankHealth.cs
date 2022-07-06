using UnityEngine;
using UnityEngine.UI;

public class TankHealth : MonoBehaviour
{
    public FloatVariable PlayerHealth;
    public GameConstants gameConstants;
    public float m_StartingHealth = 100f;
    public Slider m_Slider;
    public Image m_FillImage;
    public Color m_FullHealthColor = Color.green;
    public Color m_ZeroHealthColor = Color.red;
    public GameObject m_ExplosionPrefab;

    private AudioSource m_ExplosionAudio;
    private ParticleSystem m_ExplosionParticles;
    private float m_CurrentHealth;
    private bool m_Dead;


    private void Awake()
    {
        PlayerHealth.SetValue(gameConstants.tankStartingHealth);
        m_ExplosionParticles = Instantiate(m_ExplosionPrefab).GetComponent<ParticleSystem>();
        m_ExplosionAudio = m_ExplosionParticles.GetComponent<AudioSource>();

        m_ExplosionParticles.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (this.CompareTag("RealPlayer"))
        {
            m_CurrentHealth = PlayerHealth.Value;
            SetHealthUI();
        }
    }

    private void OnEnable()
    {
        m_CurrentHealth = gameConstants.tankStartingHealth;
        m_Dead = false;

        SetHealthUI();
    }

    public void TakeDamage(float amount)
    {
        // Adjust the tank's current health, update the UI based on the new health and check whether or not the tank is dead.
        m_CurrentHealth -= amount;
        if (this.CompareTag("RealPlayer"))
        {
            PlayerHealth.ApplyChange(-amount);
            m_CurrentHealth = PlayerHealth.Value;
        }

        SetHealthUI();
        if (m_CurrentHealth <= 0f && !m_Dead) OnDeath();
    }


    private void SetHealthUI()
    {
        // Adjust the value and colour of the slider.
        m_Slider.value = m_CurrentHealth;
        m_FillImage.color = Color.Lerp(m_ZeroHealthColor, m_FullHealthColor, m_CurrentHealth / m_StartingHealth);
    }


    private void OnDeath()
    {
        // Play the effects for the death of the tank and deactivate it.
        m_Dead = true;

        m_ExplosionParticles.transform.position = gameObject.transform.position;
        m_ExplosionParticles.gameObject.SetActive(true);
        m_ExplosionParticles.Play();
        m_ExplosionAudio.Play();

        gameObject.SetActive(false);
    }
}
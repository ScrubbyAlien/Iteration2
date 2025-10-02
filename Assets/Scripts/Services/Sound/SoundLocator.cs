using UnityEngine;

[CreateAssetMenu(fileName = "NewSoundLocator", menuName = "Locator/Sound Locator")]
public class SoundLocator : Locator<SoundService>
{
    public void PlaySound(string name) {
        registeredService.PlaySound(name);
    }
}
/*using Code.Character.Hero.HeroInterfaces;
using Code.Data.Configs.HeroConfigs;
using FMODUnity;
using UnityEngine;
using Zenject;

namespace Code.Character.Hero
{
    public class HeroAudio : MonoBehaviour, IHeroAudio
    {
        private HeroAudioPath _audioPath;

        [Inject]
        private void Construct(HeroConfig heroConfig)
        {
            _audioPath = heroConfig.AudioPath;
        }
        
        public void PlayStepSound() =>
            PlayOneShotAudio(_audioPath.Step);

        public void PlaySoftStepSound() =>
            PlayOneShotAudio(_audioPath.SoftStep);

        public void PlayOnLandSound() =>
            PlayOneShotAudio(_audioPath.OnLoad);

        public void PlayPunchSound() =>
            PlayOneShotAudio(_audioPath.Punch);
        public void PlayDamageSound() =>
            PlayOneShotAudio(_audioPath.TakeDamage);
        public void PlayJumpSound() => 
            PlayOneShotAudio(_audioPath.Jump);

        public void PLayStunnedSound() =>
            PlayOneShotAudio(_audioPath.Stunned);

        public void PlayWaterDeathSound() => 
            PlayOneShotAudio(_audioPath.WaterDeath);
        
        public void PlayDashSound()=>
            PlayOneShotAudio(_audioPath.Dash);

        public void PlayTakeGunSound() => 
            PlayOneShotAudio(_audioPath.TakeGun);

        public void PlayReturnGunSound() => 
            PlayOneShotAudio(_audioPath.ReturnGun);

        public void PlayStartShoot() => 
            PlayOneShotAudio(_audioPath.StartShoot);

        public void PlayStopShoot() => 
            PlayOneShotAudio(_audioPath.StopShoot);
        
        public void PlayShoot() => 
            PlayOneShotAudio(_audioPath.Shoot);
        private void PlayOneShotAudio(EventReference eventReference)
        {
            if (eventReference.IsNull)
                return;

            RuntimeManager.PlayOneShot(eventReference, gameObject.transform.position);
        }
    }
}*/
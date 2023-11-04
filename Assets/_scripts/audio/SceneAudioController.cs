/*using Code.Data.Configs;
using Code.Infrastructure.GlobalEvents;
using Code.Services.SaveServices;
using FMOD.Studio;
using FMODUnity;
using STOP_MODE = FMOD.Studio.STOP_MODE;


namespace Code.Audio.AudioSystem
{
    public class SceneAudioController: ISavedData
    {
        private readonly EventsFacade _eventsFacade;
        private EventReference _ambienceEvent;
        private EventReference _musicEvent;

        private EventInstance _ambience;
        private EventInstance _music;

        private PARAMETER_DESCRIPTION _dayNightParameterDescription;
        private PARAMETER_ID _dayNightParameterID;
        
        private PARAMETER_DESCRIPTION _pauseParameterDescription;
        private PARAMETER_ID _pauseParameterID;
        private PARAMETER_DESCRIPTION _heroHealthtParameterDescription;
        private PARAMETER_ID _heroHealthParameterID;

        private Bus _musicVolume;
        private Bus _effectVolume;
        private Bus _masterVolume;

        private AudioVolume _volume = new();

        public SceneAudioController(ScenesConfig scenesConfig)
        {
            InitSnapshot(scenesConfig.PauseSnapshot.Path);
            InitBus();
            InitNightParam();
            InitHeroHealthParam();
        }
        
        #region Set Audio EventReference

        private bool IsCurrentAmbienceEvent(EventReference ambienceEvent) => _ambienceEvent.Guid == ambienceEvent.Guid;

        private bool IsCurrentMusicEvent(EventReference musicEvent) => _musicEvent.Guid == musicEvent.Guid;

        private void SetAmbienceEvent(EventReference ambienceEvent) => _ambienceEvent = ambienceEvent;

        private void SetMusicEvent(EventReference musicEvent) => _musicEvent = musicEvent;

        #endregion

        #region Play

        public void ChangeSceneAudio(EventReference music ,EventReference ambience )
        {
            if (ambience.IsNull)
            {
                StopAmbience();
            }
            else if(!IsCurrentAmbienceEvent(ambience))
            {
                StopAmbience();
                SetAmbienceEvent(ambience);
                PlayAmbience();
            }

            if (music.IsNull)
            {
                StopMusic();
            }
            else if(!IsCurrentMusicEvent(music))
            {
                StopMusic();
               SetMusicEvent(music);
               PlayMusic();
            }
        }

        private void PlayAmbience()
        {
            if (_ambienceEvent.IsNull)
                return;

            _ambience = RuntimeManager.CreateInstance(_ambienceEvent);
            _ambience.start();
        }

        private void PlayMusic()
        {
            if (_musicEvent.IsNull)
                return;

            _music = RuntimeManager.CreateInstance(_musicEvent);
            _music.start();
        }

        #endregion

        #region Stop

        private void StopMusic() => _music.stop(STOP_MODE.ALLOWFADEOUT);

        private void StopAmbience() => _ambience.stop(STOP_MODE.ALLOWFADEOUT);

        #endregion
        
        #region Param
        
        private void InitNightParam()
        {
            const string nameParam = "DayNight";
            RuntimeManager.StudioSystem.getParameterDescriptionByName(nameParam, out _dayNightParameterDescription);
            _dayNightParameterID = _dayNightParameterDescription.id;
        }
        
        //value = 0 - 1
        public void ChangeNightParam(bool isNight)
        {
            var value = isNight ? 1 : 0;
            RuntimeManager.StudioSystem.setParameterByID(_dayNightParameterID, value);
        }

        private void InitHeroHealthParam()
        {
            const string nameParam = "HeroHealth";
            RuntimeManager.StudioSystem.getParameterDescriptionByName(nameParam, out _heroHealthtParameterDescription);
            _heroHealthParameterID = _heroHealthtParameterDescription.id;
        }

        public void ChancgeHeroHealthParam(float normalize)
        {
            RuntimeManager.StudioSystem.setParameterByID(_heroHealthParameterID, normalize);
        }
        
        #endregion

        #region Snapshot
        
        private EventInstance _pauseSnapshotInstance;
        private bool _isActivePauseSnapshot;
        private bool _isInit;

        private void InitSnapshot(string pauseSnapshot)
        {
            if(_isInit) return;
            _isInit = true;
            _pauseSnapshotInstance = RuntimeManager.CreateInstance(pauseSnapshot);
        }
        
        //value = 0 - 1
        public void ChangePauseParam(bool isPause)
        {
            if(isPause == _isActivePauseSnapshot)
                return;

            _isActivePauseSnapshot = isPause;
            if (isPause)
            {
               _pauseSnapshotInstance.start();
            }
            else
            {
                _pauseSnapshotInstance.stop(STOP_MODE.ALLOWFADEOUT);
            }
        }

        #endregion
        
        #region Bus

        private void InitBus()
        {
            // Path copy from FMOD
            _musicVolume = RuntimeManager.GetBus("bus:/Premaster/Music");
            _effectVolume = RuntimeManager.GetBus("bus:/SFX");
            //_master_Volume = RuntimeManager.GetBus("bus:/");
        }

        public void ChangeEffectVolume(float volume)
        {
            _volume.Effects = volume;
            _effectVolume.setVolume(volume);
        }

        public  void ChangeMusicVolume(float volume)
        {
            _volume.Music = volume;
            _musicVolume.setVolume(volume);
        }

        public  void ChangeMasterVolume(float volume)
        {
            _volume.Master = volume;
            _masterVolume.setVolume(volume);
        }

        #endregion

        public void LoadData(SavedData savedData)
        {
            ChangeEffectVolume(savedData.AudioVolume.Effects);
            ChangeMusicVolume(savedData.AudioVolume.Music);
            ChangeMasterVolume(savedData.AudioVolume.Master);
        }

        public void SaveData(SavedData savedData)
        {
            savedData.AudioVolume.Effects = _volume.Effects;
            savedData.AudioVolume.Music = _volume.Music;
            savedData.AudioVolume.Master = _volume.Master;
        }
    }
}*/
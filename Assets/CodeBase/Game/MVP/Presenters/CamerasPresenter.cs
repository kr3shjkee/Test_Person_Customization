using Cinemachine;
using CodeBase.Core.MVP.Presenter;
using CodeBase.Game.Data.Enums;
using CodeBase.Game.Elements;
using CodeBase.Game.MVP.Services;
using CodeBase.Game.MVP.Views;
using UnityEngine;
using Zenject;

namespace CodeBase.Game.MVP.Presenters
{
    public class CamerasPresenter : IPresenter, ITickable
    {
        private readonly CamerasView _view;
        private readonly CamerasService _camerasService;

        private CinemachineVirtualCamera _currentCamera;

        public CamerasPresenter(CamerasView view, CamerasService camerasService)
        {
            _view = view;
            _camerasService = camerasService;

            _camerasService.ItemCameraActivateInvoked += ActivateItemCamera;
            _camerasService.ItemCameraDeactivateInvoked += DeactivateItemCamera;
        }

        public void Enable()
        {
            DisableItemCameras();
            _view.RotateCamera.gameObject.SetActive(false);
        }

        public void Disable()
        {
            _camerasService.ItemCameraActivateInvoked -= ActivateItemCamera;
            _camerasService.ItemCameraDeactivateInvoked -= DeactivateItemCamera;
        }


        public void Tick()
        {
            if (_currentCamera == null && Input.GetMouseButtonDown(0))
            {
                _currentCamera = _view.RotateCamera;
                _view.RotateCamera.gameObject.SetActive(true);
            }

            if (_currentCamera == _view.RotateCamera && Input.GetMouseButtonUp(0))
            {
                _currentCamera = null;
                _view.RotateCamera.gameObject.SetActive(false);
            }
        }

        private void DisableItemCameras()
        {
            foreach (ItemCameraElement camera in _view.ItemCameras)
            {
                camera.gameObject.SetActive(false);
            }
        }

        private void ActivateItemCamera(ItemType type)
        {
            ItemCameraElement camera = null;
            foreach (ItemCameraElement itemCameraElement in _view.ItemCameras)
            {
                if (itemCameraElement.Types.Exists(item => item == type))
                {
                    camera = itemCameraElement;
                    break;
                }
            }
            if (camera != null)
            {
                _currentCamera = camera.Camera;
                camera.gameObject.SetActive(true);
            }
        }

        private void DeactivateItemCamera()
        {
            _currentCamera = null;
            DisableItemCameras();
            _view.RotateCamera.gameObject.SetActive(true);
            _view.RotateCamera.gameObject.SetActive(false);
        }
    }
}
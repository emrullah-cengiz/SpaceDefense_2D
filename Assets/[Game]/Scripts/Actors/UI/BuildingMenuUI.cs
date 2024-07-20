using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;
using static UnityEngine.Rendering.DebugUI;

public class BuildingMenuUI : MonoBehaviour
{
    [SerializeField] private BuildingMenuOptionUI _optionPrefab;
    [SerializeField] private Transform _optionsContainer;
    //private List<BuildingMenuOptionUI> _menuOptions;

    [Inject] private InGameDataService _inGameDataService;
    [Inject] private GameSettings _gameSettings;

    [Inject]
    private void Construct()
    {
        Events.BuildingEvents.onBuildingPlaceSelected += Show;
        Events.BuildingEvents.onBuildingSpawned += OnBuildingSpawned;
    }

    private void OnDestroy()
    {
        Events.BuildingEvents.onBuildingPlaceSelected -= Show;
        Events.BuildingEvents.onBuildingSpawned -= OnBuildingSpawned;
    }

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        var buildingsData = _inGameDataService.GetAllBuildingData();

        foreach (var buildingData in buildingsData)
        {
            Instantiate(_optionPrefab, _optionsContainer)
                .Setup(buildingData);
        }
    }

    private void Show(BuildingPlace place)
    {
        transform.position = CalculateBuildingMenuPosition(place);

        gameObject.SetActive(true);

        Events.UI.onBuildingMenuActivenessChanged?.Invoke(true);

        //isGonnaOpen = true;
        //StartCoroutine(Extensions.ExecuteOnEndOfFrame(() => );
    }

    public void Hide()
    {
        gameObject.SetActive(false);

        Events.UI.onBuildingMenuActivenessChanged?.Invoke(false);
    }

    private void OnBuildingSpawned(Building arg0) => Hide();

    private Vector3 CalculateBuildingMenuPosition(BuildingPlace place) => 
        Camera.main.WorldToScreenPoint(place.transform.position) + _gameSettings.BuildingMenuOffset;



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Hide();
    }

    //bool? s, isGonnaOpen;
    //public void OnPointerEnter(PointerEventData eventData)
    //{
    //    s = true;
    //}

    //public void OnPointerExit(PointerEventData eventData)
    //{
    //    s = false;
    //}

    //private void Update()
    //{
    //    //Mouse was clicked outside
    //    if (s.HasValue)
    //        return;

    //    if (gameObject.activeSelf && Input.GetMouseButtonDown(0) && !RectTransformUtility.RectangleContainsScreenPoint(
    //            ((RectTransform)transform),
    //            Input.mousePosition,
    //            Camera.main))
    //    {
    //        Hide();

    //        s = null;
    //    }
    //}

}

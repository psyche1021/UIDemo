using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class Controller : MonoBehaviour
{
    [SerializeField] RectTransform appIconRect; // 아이콘
    [SerializeField] RectTransform appPanelRect; // 패널
    [SerializeField] float panelDuration = 0.3f; // 패널 열리는 속도

    void Start() => appPanelRect.localScale = Vector3.zero; // 패널 초기 스케일 값

    Vector2 GetNormailzed(RectTransform target) // 정규화 좌표 구하는 함수
    {
        Vector3[] corners = new Vector3[4]; // 화면의 모서리 4군데 좌표를 저장할 배열 생성
        target.GetWorldCorners(corners); // 모서리 좌표 저장
        Vector3 center = (corners[0] + corners[2]) * 0.5f; // 모서리 좌표를 이용해 중앙 좌표 계산

        RectTransform canvas = target.GetComponentInParent<Canvas>().GetComponent<RectTransform>(); // 부모(캔버스)의 RectTransform 가져온 뒤
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas, center, null, out Vector2 localPos); // 마우스 위치를 캔버스의 로컬 좌표로 반환

        return new Vector2(Mathf.InverseLerp(canvas.rect.xMin, canvas.rect.xMax, localPos.x), Mathf.InverseLerp(canvas.rect.yMin, canvas.rect.yMax, localPos.y)); // InverseLerp는 두 범위를 값을 정규화하여 반환
    }

    public void OpenPanel() // 아이콘 누를때 반응하는 함수
    {
        Vector2 normalizedPos = GetNormailzed(appIconRect); // 아이콘 위치를 정규화 좌표로 구한 뒤
        appPanelRect.pivot = normalizedPos; // 패널의 피벗(중심점)을 정규화 좌표로 설정해서
        appPanelRect.DOScale(1f, panelDuration).SetEase(Ease.OutCubic); // 아이콘 위치에서부터 패널이 커지는 연출
    }


    public void ClosePanel() // 패널을 닫는 함수
    {
        appPanelRect.pivot = new Vector2(0.5f, 0.5f); // 피벗을 중앙으로 설정
        appPanelRect.DOScale(0f, panelDuration).SetEase(Ease.InCubic); // 패널이 작아지는 연출
    }
}
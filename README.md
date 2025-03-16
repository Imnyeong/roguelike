### ROGUELIKE TOY PROJECT
![icon](https://img.shields.io/badge/Unity-100000?style=for-the-badge&logo=unity&logoColor=white) ![icon](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)

## 개요 📝
자동 추적 로직 & 간단한 가중치 테이블

## Tech Stack ✏️
- Unity
- C#
- Visual Studio
- Sourcetree

## 기술 🔎
- 가장 가까운 적을 추적하는 자동 추적 로직
- 간단한 가중치를 활용한 뽑기 로직

## Script로 보는 핵심 기능 📰

### 자동 추적 로직
```ruby
RaycastHit2D[] targets = Physics2D.CircleCastAll(transform.position, trackRange, Vector2.zero, 0, targetLayer);

Transform target = null;
float minDistance = float.MaxValue;

foreach(RaycastHit2D curRay in targets)
{
    Vector2 charPos = transform.position;
    Vector2 targetPos = curRay.transform.position;

    float curDistance = Vector2.Distance(charPos, targetPos);
    
    if (minDistance > curDistance)
    {
        minDistance = curDistance;
        target = curRay.transform;
    }
}
return target;
```

원형으로 Raycast를 쏴서 가장 가까운 Hit 지점을 target으로 지정합니다.

### 가중치 뽑기 로직
```ruby
for (int weightCount = 0; weightCount < upgradeTable.Length; weightCount++)
{
    currentWeight += upgradeTable[weightCount].weight;

    if (weight <= currentWeight)
    {
        upgradeButtons[buttonCount].SetData(upgradeTable[weightCount]);
        break;
    }
}
```

뽑기 아이템마다 가중치를 부여하여 배열에 더해준 뒤 이전 가중치와 현재 가중치 사이의 값이 나오면 특정 아이템을 뽑습니다.

## Sample Image 🎮
<img src="https://github.com/user-attachments/assets/3b4699a4-9ce8-4174-97a8-b5cb9322b217" width="480" height="270"/>  
<img src="https://github.com/user-attachments/assets/698a6e04-f6d7-4c71-8089-49e3ad861ba3" width="480" height="270"/>

## ブロック崩し



https://github.com/warabinbin/2dBB/assets/64608456/edbb5989-6a5b-419f-9ecf-9a888df694b6



## クラスの設計
### ・Blockクラス： 
ブロックの属性や挙動を管理するクラス。耐久度の情報を持ちます。</BR>
### ・Ballクラス：
ボールの速度や挙動を制御するクラス。ボールの移動や衝突処理をこのクラス内で行います。</BR>
### ・Playerクラス： 
プレイヤーが操作するパドルを管理するクラス。</BR>
### ・Itemクラス：
パワーアップアイテムの属性や挙動を管理するクラス。異なる種類のパワーアップを簡単に追加できるようにします。</BR>
### ・GameMangerクラス：
ゲームフローを管理するクラス。スタート画面、プレイ中、ゲームオーバー画面など、異なるゲーム状態を適切に管理します。</BR>

![GameManager](https://user-images.githubusercontent.com/64608456/224575249-3728df0d-6858-4fe5-a485-c6d1f23e25cf.JPG)
https://github.com/warabinbin/2dBB/blob/main/Assets/Scripts/GameManager.cs

## 課題点
・ポーズ中点滅</Br>
・ハマるのをなくす </Br>

## ブロック崩し


<!-- https://user-images.githubusercontent.com/64608456/224575322-f85dd9be-5aa5-4379-846c-92f8807f6020.mp4-->

## GameManagerの工夫:
ゲームフローの管理：スタート画面、プレイ中、ゲームオーバー画面など、異なるゲーム状態を適切に管理する GameManagerクラスを実装しました</BR>
</BR>
https://github.com/warabinbin/2dBB/blob/main/Assets/Scripts/GameManager.cs

![GameManager](https://user-images.githubusercontent.com/64608456/224575249-3728df0d-6858-4fe5-a485-c6d1f23e25cf.JPG)
## Itemの工夫:
パワーアップアイテム：プレイヤーが特定のブロックを破壊すると、ボールの速度が上昇する、パドルが大きくなるなどのパワーアップアイテムを実装しました</BR>

## クラスの設計：
Block クラス: ブロックの属性や挙動を管理するクラスです。色や耐久度などの情報を持ちます。このクラスを活用することで、異なる種類のブロックを簡単に追加できます。</BR>

Ball クラス: ボールの速度や挙動を制御するクラスです。ボールの移動や衝突処理をこのクラス内で行います。</BR>

Paddle クラス: プレイヤーが操作するパドルを管理するクラスです。パドルの位置やサイズ、操作方法などを扱います。</BR>

PowerUp クラス: パワーアップアイテムの属性や挙動を管理するクラスです。異なる種類のパワーアップを簡単に追加できるようにします。</BR>

## 課題点
・ポーズボタンを左クリックに変更　ポーズ中点滅</Br>
・ハマるのをなくす </Br>

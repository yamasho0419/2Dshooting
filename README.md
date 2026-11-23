# 2D Shooting Game

Unity で開発したオリジナルの2Dシューティングゲームです。
本リポジトリでは、開発において独自に実装した **C# スクリプト（ソースコード）のみ** を公開しています。

## 🎮 プレイ用リンク（itch.io）

実際のゲームは、以下のリンクからブラウザ上で直接プレイできます。
👉 [https://yamasina.itch.io/2dshotinggame](https://yamasina.itch.io/2dshotinggame)

## 作った理由

Unity で面白いゲームを作りたい、という純粋な思いから作りました。

## 遊んでもらい、直す

インディーゲームの交流会に持っていき、いろいろな人に遊んでもらいました。
もらったフィードバックをもとにゲームを手直しし、また遊んでもらう、というサイクルを回しました。
海外から来た方も多く、英語で感想を聞くことが英会話の勉強にもなりました。

## 主なスクリプト

| ファイル | 役割 |
|---|---|
| `PlayerController.cs` | プレイヤーの操作 |
| `EnemySpawner.cs` / `StageData.cs` / `stagecontroller.cs` | 敵の出現とステージの進行 |
| `BulletContoroller.cs` / `BulletType.cs` | 弾の動きと種類 |
| `ScoreManager.cs` | スコア |
| `Soundmanagement.cs` | 効果音・BGM |

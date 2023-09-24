<!DOCTYPE html>
<html>
  <head>
    <title>PHPでHTMLを作成する例</title>
  </head>
  <body>
    <?php
      // PHPコードで変数を定義する
      $name = "John Smith";
    ?>
    <!-- 変数を使用してHTMLコードを生成する -->
    <h1><?php echo "こんにちは、" . $name . "さん！"; ?></h1>
    <p>今日は<?php echo date("Y年m月d日"); ?>です。</p>
  </body>
</html>

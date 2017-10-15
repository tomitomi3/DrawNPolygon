# Introduction
MATH POWER 2017(http://mathpower.sugakubunka.com/)
のプログラムで「眺めて愛でる数式美術館 あなたも数式を眺めてみませんか？」に出てきた正n角形の式を用いて正n角形を描きます（正しくは点を打つ）

# Method

* 正n角形の式

![eq](https://github.com/tomitomi3/DrawNPolygon/blob/master/_pic/eq_1.png)
![eq](https://github.com/tomitomi3/DrawNPolygon/blob/master/_pic/eq_2.png)



正n角形の式が成立するときに点を打つことで描いているように見せています。



# Result

* 三角形

![result](https://github.com/tomitomi3/DrawNPolygon/blob/master/_pic/result_triangle.PNG)

* 四角形

![result](https://github.com/tomitomi3/DrawNPolygon/blob/master/_pic/draw_rectangle.PNG)

* 五角形

![result](https://github.com/tomitomi3/DrawNPolygon/blob/master/_pic/draw_pentagon.PNG)

* 65537角形

![result](https://github.com/tomitomi3/DrawNPolygon/blob/master/_pic/draw_65537.PNG)

* Memo

上の数式はCODECOGS ( https://www.codecogs.com/latex/eqneditor.php ) を使いました。

> x^{2} + y^{2} = 1 + p(x,y,n)^{2}
> p(x,y,n) = tan \left [ \frac{2}{n} tan^{-1} tan\left \{ \frac{n}{2} \left ( tan^{-1} \frac{x}{y} -  \frac{\pi}{2} sign y \right ) \right \} \right ]


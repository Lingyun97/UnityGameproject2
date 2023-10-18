# UnityGameproject2
Unity platform game
ChingMu Vrpn for matlab simulink<br>
操作说明：<br>
1.将.dll、.h、.m文件放到同一路径下，并在matlab中将当前文件夹改为该路径。<br>
2.在Matlab中执行：mex -setup， 安装VS 2017编译器。<br>
3.修改getVrpnArray.m中的VrpnServer地址。<br>
4.打开Simulink_Multi_NoDisplay.slx，修改Body ID input。<br>
5.使用Simulation下的运行开始接收数据。<br>
6.退出matlab前，按序调用以下命令卸载dll:<br>
&emsp;&emsp;calllib('CMVrpn', 'CMUnityQuitExtern');<br>
&emsp;&emsp;unloadlibrary('CMVrpn');<br>

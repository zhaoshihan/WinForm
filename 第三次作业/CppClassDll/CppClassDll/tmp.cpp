#include <iostream>
#include <iomanip>
#include <algorithm> // sort() lower_bound() max() min()
#include <string>
#include <cstring> // memset()
#include <map>
#include <set>
#include <vector>
#include <queue>
#include <stack>
#include <climits> // INT_MAX

using namespace std;
const int INF = 0x3f3f3f3f;

int main() {
	//初始化输入
	int N, K;
	printf("please input N, K\n");
	scanf("%d%d", &N, &K);
	double** array = new double* [N];
	for (int i=0; i< N; i++)
	{
		array[i] = new double[2];
		printf("please input X%d point\n", i+1);
		scanf("%f%f", &array[i][0], &array[i][1]);
	}
	//选定Z
	double** Z_array = new double*[K];
	for (int i=0; i<K; i++)
	{
		Z_array[i] = new double[2];
		Z_array[i][0] = array[i][0];
		Z_array[i][1] = array[i][1];
	}

	//计算距离
L2:	vector<vector<int>> tmp_set;
	for (int i = 0; i < N; i++) {
		double* tmp = new double[K];
		double min = INF;
		int point = 0;
		for (int j = 0; j < K; j++) {
			tmp[j] = sqrt(pow(array[i][0] - array[j][0], 2) + pow(array[i][1] - array[j][1], 2));
			if (tmp[j] < min) {
				min = tmp[j];
				point = j;
			}
		}
		tmp_set[point].push_back(i);
	}


	//计算新聚类中心
	int i = 0;
	for (vector<vector<int>>::iterator it = tmp_set.begin(); it != tmp_set.end(); ++it)
	{
		int num;
		count(it->begin(), it->end(), num);
		double x = 0;
		double y = 0;
		for (int i = 0; i < num; i++) {
			x += array[*(it->begin() + num)][0];
			y += array[*(it->begin() + num)][1];
		}
		x = x / num;
		y = y / num;

		if (x != Z_array[i][0] || y != Z_array[i][1])
		{
			Z_array[i][0] = x;
			Z_array[i][1] = y;
			goto L2;
		}
		i++;
	}
	return 0;
}

extern "C" _declspec(dllexport) int sumTwo(int var_x, int var_y) 
{
	return var_x + var_y;
}

extern "C" _declspec(dllexport) int minusTwo(int var_x, int var_y)
{
	return var_x - var_y;
}

extern "C" _declspec(dllexport) int multiplyTwo(int var_x, int var_y)
{
	return var_x * var_y;
}

extern "C" _declspec(dllexport) double divideTwo(double var_x, double var_y)
{
	return var_x / var_y;
}
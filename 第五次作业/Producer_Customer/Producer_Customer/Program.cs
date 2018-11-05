using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BoundedBufferProblem
{
    class Item
    {
        public string name;
        static int productNumber = 0;
        // 产品队列缓存
        static Queue<Item> queue = new Queue<Item>();
        static readonly int BUFFER_SIZE = 3;

        // 同步标记
        private static int ItemCount = 0;
        static Semaphore fillCount = new Semaphore(0, BUFFER_SIZE);     // 消费权限
        static Semaphore emptyCount = new Semaphore(BUFFER_SIZE, BUFFER_SIZE);  // 生产权限
        static Mutex bufferMutex = new Mutex();



        static Thread producerThread;
        static Thread producerThread2;

        static Thread consumerThread;
        static Thread consumerThread2;
        static Thread consumerThread3;

        static void Main(string[] args)
        {
            producerThread = new Thread(producer2);
            producerThread2 = new Thread(producer2);


            consumerThread = new Thread(consumer2);
            consumerThread2 = new Thread(consumer2);
            consumerThread3 = new Thread(consumer2);

            producerThread.Start();
            producerThread2.Start();

            consumerThread.Start();
            consumerThread2.Start();
            consumerThread3.Start();
        }

        // 将产品放入缓存中
        static void putItemIntoBuffer(Item item)
        {
            queue.Enqueue(item);
            Console.WriteLine("将" + item.name + "放入队列，现在有" + queue.Count + "个");
        }

        // 从缓存中获取产品
        static Item removeItemFromBuffer()
        {
            var item = queue.Peek();
            queue.Dequeue();
            Console.WriteLine("将" + item.name + "取出队列，现在有" + queue.Count + "个");
            return item;
        }

        // 生产产品
        static Item ProduceItem(int number)
        {
            Thread.Sleep(TimeSpan.FromSeconds(1));
            Item item = new Item() { name = "产品" + number };
            Console.WriteLine("生产了" + item.name);
            return item;
        }

        // 消费产品
        static void ConsumItem(Item item)
        {
            Thread.Sleep(TimeSpan.FromSeconds(2));
            Console.WriteLine("消费了" + item.name);
        }

        static void producer1()
        {
            while (true)
            {
                var item = ProduceItem(productNumber++);

                // 还有生产权限时，进入下面的代码
                emptyCount.WaitOne();
                // 将产品放入buffer中
                putItemIntoBuffer(item);
                // 释放一个拿去权限
                fillCount.Release();
                // fillCount是已经填了多少，而emptyCount是没有填的数量
            }
        }

        static void consumer1()
        {
            while (true)
            {
                // 等待一个拿去权限
                fillCount.WaitOne();
                // 移除一个物品
                var item = removeItemFromBuffer();
                // 释放一个生产权限
                emptyCount.Release();
                ConsumItem(item);
            }
        }

        static void producer2()
        {
            while (true)
            {
                var item = ProduceItem(productNumber++);

                // 还有生产权限时，进入下面的代码
                emptyCount.WaitOne();
                bufferMutex.WaitOne();

                // 将产品放入buffer中
                putItemIntoBuffer(item);
                bufferMutex.ReleaseMutex();

                // 释放一个拿去权限
                fillCount.Release();
            }
        }

        static void consumer2()
        {
            while (true)
            {
                // 等待一个拿去权限
                fillCount.WaitOne();
                bufferMutex.WaitOne();

                // 移除一个物品
                var item = removeItemFromBuffer();
                bufferMutex.ReleaseMutex();

                // 释放一个生产权限
                emptyCount.Release();
                ConsumItem(item);
            }
        }
    }
}

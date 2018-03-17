using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LetsStart
{
    public partial class Form1 : Form
    {

        enum coin
        {
            penny, nickel, dime, quarter,
            half_dollar, dollar
        } ;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] names = {
                  "penny",
                  "nickel",
                  "dime",
                  "quarter",
                  "half_dollar",
                  "dollar"
            } ;

            coin i; // 列挙型の変数を宣言

            // 列挙を使ってループする
            for(i = coin.penny; i <= coin.dollar; i++) //←coin型の変数がforループを制御
              Console.WriteLine(names[(int)i] + " has value of " + (int)i);
            }

        
    }

    // 文字用の固定サイズキュー
    class FixedQueue : ICharQ
    {
        char[] q;　// キューのデータを保持する配列
        int putloc, getloc;　// データの取得・参照のためのインデックス

        // 指定されたサイズの空のキューを作成する
        public FixedQueue(int size)
        {
            q = new char[size + 1];　// キューのためにメモリ領域を確保
            putloc = getloc = 0;
        }

        // キューに1文字を入れる
        public void put(char ch)
        {
            if (putloc == q.Length - 1)
            {
                Console.WriteLine(" -- Queue is full.");
                return;
            }

            putloc++;
            q[putloc] = ch;
        }

        // キューから1文字を取り出す
        public char get()
        {
            if (getloc == putloc)
            {
                Console.WriteLine(" -- Queue is empty.");
                return (char)0;
            }

            getloc++;
            return q[getloc];
        }
    }

    // 循環キュー
    class CircularQueue : ICharQ
    {
        char[] q;　// キューのデータを保持する配列
        int putloc, getloc;　// データの取得・参照のためのインデックス

        // 指定されたサイズの空のキューを作成する
        public CircularQueue(int size)
        {
            q = new char[size + 1];　// キューのためにメモリ領域を確保
            putloc = getloc = 0;
        }

        // キューに1文字を入れる
        public void put(char ch)
        {
            /* putlocがgetlocよりも1だけ小さいか、
               またはputlocが配列末尾でgetlocが配列先頭ならば、
               キューはいっぱいである */
            if (putloc + 1 == getloc |
               ((putloc == q.Length - 1) & (getloc == 0)))
            {
                Console.WriteLine(" -- Queue is full.");
                return;
            }

            putloc++;
            if (putloc == q.Length) putloc = 0;　// キューの先頭に戻る
            q[putloc] = ch;
        }

        // キューから1文字取り出す
        public char get()
        {
            if (getloc == putloc)
            {
                Console.WriteLine(" -- Queue is empty.");
                return (char)0;
            }

            getloc++;
            if (getloc == q.Length) getloc = 0;　// キューの先頭に戻る
            return q[getloc];
        }
    }

    // 動的キュー
    class DynQueue : ICharQ
    {
        char[] q;　// キューのデータを保持する配列
        int putloc, getloc;　// データの取得・参照のためのインデックス

        // 指定されたサイズの空のキューを作成する
        public DynQueue(int size)
        {
            q = new char[size + 1];　// キューのためにメモリ領域を確保
            putloc = getloc = 0;
        }

        // キューに1文字を入れる
        public void put(char ch)
        {
            if (putloc == q.Length - 1)
            {
                // キューのサイズを拡大する
                char[] t = new char[q.Length * 2];

                // 既存要素を新しいキューにコピーする
                for (int i = 0; i < q.Length; i++)
                    t[i] = q[i];

                q = t;
            }

            putloc++;
            q[putloc] = ch;
        }

        // キューから1文字を取り出す
        public char get()
        {
            if (getloc == putloc)
            {
                Console.WriteLine(" -- Queue is empty.");
                return (char)0;
            }

            getloc++;
            return q[getloc];
        }
    }

    // 文字用キューのインターフェイス
    public interface ICharQ
    {
        // 1文字をキューに追加する
        void put(char ch);

        // 1文字をキューから取り出す
        char get();
    }

}


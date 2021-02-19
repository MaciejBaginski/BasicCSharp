using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Zadanie2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Questionnaire Questionnaire = null;
        private RadioButton checkedRadioButton = null;
        private readonly List<RadioButton> radioButtons = new List<RadioButton>();
        private readonly Dictionary<RadioButton, Answer> answerDict = new Dictionary<RadioButton, Answer>();

        public MainWindow()
        {
            InitializeComponent();

            radioButtons.Add(Answer1);
            radioButtons.Add(Answer2);
            radioButtons.Add(Answer3);
            radioButtons.Add(Answer4);

            answerDict[Answer1] = null;
            answerDict[Answer2] = null;
            answerDict[Answer3] = null;
            answerDict[Answer4] = null;

            InitPanel();
        }

        private void InitPanel()
        {
            UncheckRadioButtons();
            ResetQuestionMap();
            SetResultLabelContent("");
            SetQuestionLabelContent("");

            NextButton.IsEnabled = false;
            StartButton.IsEnabled = true;
        }

        private void ClearPanelAfterEnd()
        {
            UncheckRadioButtons();
            ResetQuestionMap();
            SetQuestionLabelContent("");
        }

        private void ClearPanelBeforeStart()
        {
            UncheckRadioButtons();
            ResetQuestionMap();
            SetQuestionLabelContent("");
            SetResultLabelContent("");
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClearPanelBeforeStart();
                Questionnaire = new Questionnaire();
                StartQuestionnaire();
            }
            catch (QuestionnaireException exc)
            {
                HandleQuestionnaireException(exc);
            }
        }

        private void StartQuestionnaire()
        {
            
            Question question = Questionnaire.ReturnFirstQuestion();
            if(question != null)
            {
                SetQuestion(question);
                StartButton.IsEnabled = false;
            } 
            else
            {
                throw new QuestionnaireException("Missing questions");
            }
        }

        private void SetQuestion(Question question)
        {
            SetQuestionMap(question.Answers);
            SetQuestionLabelContent(question);
        }

        

        private void ShowAnswers()
        {
            foreach (RadioButton radioButton in answerDict.Keys)
            {
                if(answerDict[radioButton] != null)
                {
                    string message = answerDict[radioButton].ToString();
                    radioButton.Content = message;
                    radioButton.IsEnabled = true;
                } 
                else
                {
                    radioButton.Content = "";
                    radioButton.IsEnabled = false;
                }
            }
        }

        private void SetQuestionMap(List<Answer> answers)
        {
            List<RadioButton>.Enumerator radioButtonsEnumerator = answerDict.Keys.ToList().GetEnumerator();
            foreach (Answer answer in answers)
            {
                radioButtonsEnumerator.MoveNext();
                answerDict[radioButtonsEnumerator.Current] = answer;
            }
            ShowAnswers();
        }

        private void ResetQuestionMap()
        {
            answerDict.Keys.ToList().ForEach(element => answerDict[element] = null);
            ShowAnswers();
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Answer answer = answerDict[checkedRadioButton];
                Question question = Questionnaire.ReturnNextQuestion(answer);

                UncheckRadioButtons();
                ResetQuestionMap();

                if (question != null)
                {
                    SetQuestion(question);
                    NextButton.IsEnabled = false;
                }
                else
                {
                    SetResultLabelContent(Questionnaire.GetResult());
                    StartButton.IsEnabled = true;
                    ClearPanelAfterEnd();
                }

                NextButton.IsEnabled = false;
                
            }
            catch (QuestionnaireException exc)
            {
                HandleQuestionnaireException(exc);
            }
        }

        private void HandleQuestionnaireException(QuestionnaireException e)
        {
            SetResultLabelContentAsError("Error: " + e.Message);
        }

        private void Answer_Checked(object sender, RoutedEventArgs e)
        {
            checkedRadioButton = sender as RadioButton;
            NextButton.IsEnabled = true;
        }

        private void SetResultLabelContent(string val)
        {
            ResultField.Background = null;
            ResultField.Content = val;
        }

        private void SetResultLabelContentAsError(string val)
        {
            ResultField.Background = Brushes.Tomato;
            ResultField.Content = val;
        }

        private void SetQuestionLabelContent(Question question)
        {
            QuestionField.Content = question.ToString();
        }

        private void SetQuestionLabelContent(string val)
        {
            QuestionField.Content = val;
        }

        private void UncheckRadioButtons()
        {
            if (checkedRadioButton != null)
            {
                checkedRadioButton.IsChecked = false;
                checkedRadioButton = null;
            }
        }

    }
}

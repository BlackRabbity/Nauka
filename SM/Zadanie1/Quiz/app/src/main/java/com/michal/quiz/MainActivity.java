package com.michal.quiz;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;

import lombok.Getter;
import lombok.Setter;

public class MainActivity extends AppCompatActivity {

    private Button trueButton;
    private Button falseButton;
    private Button nextButton;
    private TextView questionTextView;

    @Override
    protected void onCreate(Bundle savedInstanceState){
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        trueButton = findViewById(R.id.true_button);
        falseButton = findViewById(R.id.false_button);
        nextButton = findViewById(R.id.next_button);
        questionTextView = findViewById(R.id.question_text_view);
        trueButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                checkAnswerCorrectness(true);
            }
        });
        falseButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                checkAnswerCorrectness(false);
            }
        });
        nextButton.setOnClickListener(new View.OnClickListener(){
            @Override
            public void onClick(View v){
                currentIndex = (currentIndex + 1)%questions.length;
                setNextQuestion();
            }
        });
    }
    @Getter
    @Setter
    public class Question {
        private int questionId;
        private boolean trueAnswer;

        public Question (int questionId, boolean trueAnswer)
        {
            this.questionId = questionId;
            this.trueAnswer = trueAnswer;
        }
    }
    private Question[] questions = new Question[]{
            new Question(R.string.q_1, true),
            new Question(R.string.q_2, false),
            new Question(R.string.q_3, true),
            new Question(R.string.q_4, true),
            new Question(R.string.q_5, false),
    };
    private int currentIndex = 0;
    private void checkAnswerCorrectness(boolean userAnswer)
    {
        boolean correctAnswer = questions[currentIndex].isTrueAnswer();
        int resultMessageId = 0;
        if (userAnswer == correctAnswer){
            resultMessageId = R.string.correct_answer;
        } else {
            resultMessageId = R.string.incorrect_answer;
        }
        Toast.makeText(this, resultMessageId, Toast.LENGTH_SHORT).show();
    }
    private void setNextQuestion(){
        questionTextView.setText(questions[currentIndex].getQuestionId());
    }
}
package com.github.elitonluiz1989.financemanager

import androidx.compose.material3.MaterialTheme
import androidx.compose.runtime.Composable
import com.github.elitonluiz1989.financemanager.presentation.HomeScreen
import org.jetbrains.compose.ui.tooling.preview.Preview

@Composable
@Preview
fun App() {
    MaterialTheme {
        HomeScreen()
    }
}
package com.github.elitonluiz1989.financemanager

import androidx.compose.ui.window.Window
import androidx.compose.ui.window.application
import financemanager.composeapp.generated.resources.Res
import financemanager.composeapp.generated.resources.app_name
import org.jetbrains.compose.resources.stringResource

fun main() = application {
    Window(
        onCloseRequest = ::exitApplication,
        title = stringResource(Res.string.app_name),
    ) {
        App()
    }
}
